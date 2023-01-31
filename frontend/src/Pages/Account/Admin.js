import React, { useState } from 'react';
import Alinea from '../Shared/Alinea';
import Hero2 from '../Shared/Hero2';
import ZaalToevoegen from './TheaterzaalMaken.js/ZaalToevoegen';
import RuimteToevoegen from './TheaterzaalMaken.js/RuimteToevoegen';
import RijToevoegen from './TheaterzaalMaken.js/RijToevoegen';

const Admin = () => {
    const [optionState, setOptionState] = useState(1);
    const [addZaal, setAddZaal] = useState(0);

    const [roomname, setRoomname] = useState("");
    const [roomnumber, setRoomnumber] = useState(0);
    const [capaciteit, setCapaciteit] = useState("");

    const [elementID, setElementID] = useState(0)

    const [rangnummer, setRangnummer] = useState(0);
    const [rijZaal, setRijZaal] = useState(0);
    const [rijCapaciteit, setRijCapaciteit] = useState(0);

    const [success, setSuccess] = useState(false);

    const clearValues = () => {
        setRoomname("");
        setAddZaal(0);
        setRoomnumber(0);
        setCapaciteit("");
        setElementID(0);
        setRangnummer(0);
        setRijZaal(0);
        setRijCapaciteit(0);
        setSuccess(false);
    }

    function updateDiv() {

    }

    const handleSubmit = async (e) => {
        e.preventDefault();
    }


    return (
        <>{success ? (
            <>
                <Hero2 tekst="Zalen configureren" />
                <Alinea teksts="Zaal met succes toegevoegd." />
                <button className="btn" onClick={(e) => clearValues()}>Nog een zaal toevoegen?</button>
            </>
        ) : (
            <>
                <Hero2 tekst="Zalen configureren" />
                <section className="contact">
                    <Alinea titel="Type" tekst="Kies uit zaal, Ruimte of Rij" />


                    <select id="selector" required="required" onChange={e => setOptionState(e.target.value)}>
                        <option value="0" disabled selected>Selecteer een zaal</option>
                        <option value="1">Zaal toevoegen</option>
                        <option value="2">Ruimte toevoegen</option>
                        <option value="3">Rij toevoegen</option>
                    </select>


                    <p>Option State: {optionState}</p>

                    <div id="formcontainer">
                        {optionState === "1" ? (
                            <>
                                <ZaalToevoegen />
                            </>
                        ) : (
                            <>
                                {optionState === "0" ? (<Alinea tekst="kies een optie" />) : (<></>)}
                            </>)}
                        {optionState === "2" ? (
                            <>
                                <RuimteToevoegen />
                            </>
                        ) : (
                            <>
                                {optionState === "0" ? (<p>optie status is 0</p>) : (<></>)}
                            </>)}
                        {optionState === "3" ? (
                            <>
                                <RijToevoegen />
                            </>
                        ) : (
                            <>
                            </>)}
                    </div>
                </section>
            </>)}
        </>
    );
}


export default Admin;