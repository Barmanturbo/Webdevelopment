import React from 'react';
import Hero2 from '../Shared/Hero2';
import Alinea from '../Shared/Alinea';
import { useRef, useState, useEffect, useContext} from "react";
import AuthContext from "../../context/AuthProvider";
import axios from "../../api/axios";

const LOGIN_URL = "/api/Gebruiker//";

const Login = (props) => {
    const { setAuth } = useContext(AuthContext);

    //sets focus on error message for screenreaders
    const userRef = useRef();
    const errRef = useRef();

    const [gebruikersnaam, setGebruikersnaam] = useState("");
    const [wachtwoord, setWachtwoord]=useState("");
    const [formData, setFormData]=useState("");

    const [errMsg, setErrMsg] = useState("");
    const [success, setSuccess] = useState(false);

    //This is just here to prevent warnings since azure doesn't like unused variables
    const placeholder = () => {
        console.log (setWachtwoord);
        console.log (setGebruikersnaam);
        console.log (formData);
        console.log (setFormData);
    }

    useEffect(()=>{
        userRef.current.focus();
    },[]);

    const handleSubmit = async (e) => {
        e.preventDefault();
        console.log (placeholder);

        try{
            const response = await axios.post(
                LOGIN_URL,
                JSON.stringify({username: gebruikersnaam, pass:wachtwoord}),
                {headers:{'Content-Type': 'application/json'},withCredentials:true}
            );

            console.log(JSON.stringify(response?.data));
            //const accessToken = response?.data?.accessToken;
            const roles = response?.data?.rol;
            setAuth({gebruikersnaam, wachtwoord, roles/*, accessToken*/});
            setGebruikersnaam("");
            setWachtwoord("");
            setSuccess(true);   
        }catch(err){
            if(!err?.response){
                setErrMsg('No Server Response')
            }else{
                if(err.response?.status === 400){
                    setErrMsg('Gebruikersnaam of wachtwoord ontbreekt');
                }else{
                    setErrMsg('Login lukte niet');
                }
                errRef.current.focus();
            }
        }

        console.log(gebruikersnaam);
        console.log(wachtwoord);
    }

    return (
        <>
            {success ? (
                <>
                    <Hero2 tekst = "Inloggen"/>
                    <Alinea titel="U bent ingelogd" tekst="U bent al ingelogd"/>
                </>
            ):(
                <>
                    <Hero2 tekst="Inloggen" />
                        
                    <section className="contact">
                        <p ref={errRef} className={errMsg?"errmsg":"offscreen"} aria-live="assertive">{errMsg}</p>
                        <form onSubmit={handleSubmit}>
                            <label htmlFor="gebruikersnaam">Gebruikersnaam:</label>
                            <input
                                value={gebruikersnaam}
                                type="text"
                                ref={userRef}
                                placeholder={props.tekst}
                                onChange={(e)=> setGebruikersnaam(e.target.value)}
                                id="gebruikersnaam"
                                name="gebruikersnaam"
                                required
                            />
                            <br/>
                            <label htmlFor="wachtwoord">Wachtwoord:</label>
                            <input
                                value={wachtwoord}
                                type="password"
                                placeholder={props.tekst}
                                onChange={(e)=>setWachtwoord(e.target.value)}
                                id="wachtwoord"
                                name="wachtwoord"
                                required
                            />
                            <button className="btn" onClick={handleSubmit} type="submit">Log in</button>
                        </form>
                        <p id='LinkNaarAanmaken'><br/>Heeft u nog geen account? <br/><a href='/Aanmaken'>Maak hier uw account aan.</a></p>
                    </section>
                </>
            )} 
        </>
    );
}

export default Login;
