import React, { useState }  from 'react';
import Alinea from '../Shared/Alinea';
import Hero2 from '../Shared/Hero2';

const ZaalToevoegen = () => {
    const [addZaal, setAddZaal] = useState(0);
    const [roomname, setRoomname] = useState("");

    const [capaciteit,setCapaciteit] = useState("");

    /*const handleSubmit = async () => {
        try {
            let res = await fetch("https://localhost:7214/api/Show", {
                method: "POST",
                headers: {
                "Content-Type": "application/json",
                },
                body: JSON.stringify({
                shownr: 0,
                afbeelding: "string",
                genre: showgenre,
                naam: shownaam,
                leeftijdsgroep: leeftijd,
                zaal: showzaal,
                beginTijd: "2023-01-22T22:09:07.168Z",
                eindTijd: "2023-01-22T22:09:07.168Z"
                }),
            });
          if (res.status === 200) {
            console.log("succes");
          }
        } catch (err) {
          console.log(err);
        }
    }*/

    return (
        <>
            <Hero2 tekst="Zalen configureren" />
            <section className="contact">
                <h3>Type</h3>
                <p>Kies uit Zaal, Ruimte of Rij</p>
                <select required="required" onchange={(e)=>setAddZaal(e.target.value)}>
                    <option value="0" disabled seleccted>Selecteer een zaal</option>
                    <option value="1">Zaal toevoegen</option>
                    <option value="2">Ruimte toeevoegen</option>
                    <option value="3">Rij toevoegen</option>
                </select>
                {addZaal===0?(
                    <Alinea titel="Kies een optie."/>
                ):(
                    <>
                    {addZaal===1?(
                        <>{/*Zaal toevoegen */}
                            <form>
                                <label htmlfor="zaalnaam">Zaalnaam:</label><br/>
                                <input type="text" id="zaalnaam" autoComplete="off" onChange={(e)=>setRoomname(e.target.value)} required/>
                                <br/>
                                <label htmlfor="aantalStoelen">Aantal Stoelen:</label><br/>
                                <input type="number" id="aantalStoelen" autoComplete="off" onChange={(e)=>setCapaciteit(e.target.value)} required/>


                            </form>
                        </>
                    ):(
                        <><Alinea/>
                        </>
                    )}
                    </>
                )}
            </section>   
        </>
    );
}

export default ZaalToevoegen;