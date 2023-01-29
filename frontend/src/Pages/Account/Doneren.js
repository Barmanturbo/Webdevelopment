import React from "react";
import Hero2 from "../Shared/Hero2";
import ikDoneer from "./ikDoneer";

const Account = () => {
    const [donatie, setDonatie]=useRef();
    const errRef = useRef();
    const [errMsg, setErrMsg] = useState("");

    const handleSubmit = async (e) => {
        console.log(donatie);

    }

    //https://ikdoneer.azurewebsites.net/Rollen
    return(
        <>
            <Hero2 tekst="Doneren"/>
            <Alinea titel="Doneren" 
                tekst="Door het doneren van geld aan het Laaktheater
                maakt het voor ons mogelijk om toegang tot het theater
                voor mensen die het minder breed hebben goedkoper te maken.
                Op deze manier helpt u mee culturele uitstapjes betaalbaar te houden."
            /> {/*Alinea is een h3 met een p er onder.*/}
            <br/>
            <h3>Voordelen</h3>
            <p>
                Als u minstens &#8364;1000 doneert, krijgt u de volgende voordelen:
                <ul>
                    <li>U kan ervroegd kaartjes reserveren</li>
                    <li>U kan Concept planning theaterseizoen inzien</li>
                    <li>U krijgt toegang tot een speciale webpagina</li>
                </ul>
            </p>
            <hr/>
            <>{auth != null ?(
                <section className="contact">
                    <p ref={errRef} className={errMsg?"errmsg":"offscreen"} aria-live="assertive">{errMsg}</p>
                    <form onSubmit={handleSubmit}>
                        <label htmlFor="DonatieHoeveelheid">Hoeveel geld wilt u doneren?</label>
                        <input
                            value={donatie}
                            type="number"
                            id="DonatieBedrag"
                            name="DonatieBedrag"
                            onChange={(e)=>setDonatie(e.target.value)}
                        />
                        <button className="btn">Maak donatie over</button>{/*Since it is the only button in a form, it automatically submits */}
                    </form>
                    <br/>
                    <p>{donatie} euro doneren? </p>
                    
                    <ikDoneer bedrag={donatie}/>
                    
                    <hr/>
                </section>
            ):(
                <section className="contact">
                    <Alinea
                        titel="U bent nog niet ingelogd."
                        tekst="Log eerst in voor u kan doneren."
                        link="/Login"
                        linknaam="Log hier in."
                    /> 
                </section>
            )}
            </>
        </>
    );
}

export default Account;