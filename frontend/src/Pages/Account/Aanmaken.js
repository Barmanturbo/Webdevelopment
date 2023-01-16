import React from 'react';
import Hero2 from '../Shared/Hero2';
import { useState } from "react";
import PasswordChecklist from "react-password-checklist";

/*https://www.npmjs.com/package/react-password-checklist*/

const Aanmaken = () => {
    const [naam, setNaam] = useState();
    const [password, setPassword] = useState("");
    const [confirmPassword, setConfirmPassword] = useState("");
    const [email, setEmail] = useState();
    const [date, setDate] = useState();
    var regex = 

    const handleSubmit = (e) => {
        e.preventDefault();
        alert(naam + email + date);
    }

    return (
        <>
            <Hero2 tekst="Account aanmaken" />
                
            <section className="contact">
             <form>
                <p>Gebruikersnaam:</p>
                <input type="text" onChange={e => setNaam(e.target.value)}/>
                
                <p>Wachtwoord:</p>
                <input type="password" pattern="(?=.*[a-z])(?=.*[A-Z])(?=.*[$&+,:;=?@#|'<>.^*()%!-]).{7,}" onChange={e => setPassword(e.target.value)}/>
                <p>Bevestig wachtwoord:</p>
                <input type="password" onChange={e => setConfirmPassword(e.target.value)}/>

                <PasswordChecklist
                //these are the default rules
				rules={["minLength","specialChar","number","capital","lowercase","match"]}
				minLength={7}
                capital={1}
                lowercase={1}
                specialChar={1}
				value={password}
				valueAgain={confirmPassword}
                messages={{
                    // this changes the default messages
                    minLength: "Minimaal 7 karakters",
                    specialChar: "Minimaal 1 speciaal karakter",
                    number: "Minimaal 1 getal",
                    capital: "Minimaal 1 hoofdletter",
                    lowercase: "Minimaal 1 kleine letter",
                    match: "Wachtwoorden moeten overeen komen",
                }}
				onChange={(isValid) => {}}
			    />
                <br></br>

                <p>Email</p>
                <input type="email" pattern="[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,}" onChange={e => setEmail(e.target.value)}/>
                
                <p>Geboortedatum</p>
                <input type="date" onChange={e => setDate(e.target.value)} />

                <button className="btn" onClick={handleSubmit}> Submit </button>
            </form>
            </section>   
        </>
    );
}

export default Aanmaken;