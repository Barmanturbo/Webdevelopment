import React from "react";
import Alinea from "../Shared/Alinea";
import Hero2 from "../Shared/Hero2";

const Account = () => {
    return(
        <>
            <Hero2 tekst="Mijn account"/>

            <Alinea titel="Inloggen" 
                tekst="U bent momenteel nog niet ingelogd, log in om uw account te bekijken."
                link="/Login"
                linknaam="Klik hier om in te loggen"
                tekst2="Heeft u nog geen account?"
                link2="/Aanmaken"
                linknaam2="Klik dan hier om een account aan te maken"/>

            <Alinea titel="Donatie"
                tekst="Wilt u ons helpen om de website te onderhouden en te verbeteren? Doneer dan via onderstaande link."
                link="/Doneren"
                linknaam="Klik hier om te doneren"/>

            <Alinea titel="Medewerkers"
                tekst="Wilt u een evenement toevoegen?"
                link="/ShowToevoegen"
                linknaam="Klik hier om een evenement toe te voegen"/>
            
            <Alinea titel="Admins"
                tekst="Wilt u zalen configureren?"
                link="/Admin"
                linknaam="Klik hier om zalen te configureren"/>
        </>
    );
}

export default Account;