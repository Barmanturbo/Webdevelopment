import React, { useState }  from 'react';
import Alinea from '../Shared/Alinea';
import Hero2 from '../Shared/Hero2';

const ZaalToevoegen = () => {
    const [addZaal, setAddZaal] = useState(0);

    const [roomname, setRoomname] = useState("");
    const [roomnumber, setRoomnumber] = useState("");
    const [capaciteit,setCapaciteit] = useState("");

    const [rangnummer, setRangnummer] = useState(0);
    const [rijZaal, setRijZaal] = useState(0);
    const [rijCapaciteit, setRijCapaciteit] = useState(0);
    const handleSubmit=async()=>{
        try{

        }catch(err){
            console.log(err);
        }
    }

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
                {addZaal!=2||addZaal!=3?(
                    <>{/*checks for only legal values */}
                        { addZaal=== 1?(
                            
                            <>{/*Zaal toevoegen */}
                                <h3>Zaal toevoegen:</h3>
                                <form onSubmit={handleSubmit}>
                                    <label htmlfor="zaalnaam">Zaalnaam:</label><br />
                                    <input type="text" id="zaalnaam" autoComplete="off" onChange={(e) => setRoomname(e.target.value)} required />
                                    <br />
                                    <label htmlfor="zaalnummer">Zaalnummer:</label><br/>
                                    <input type="number" id="zaalnummer" autoComplete="off" onChange={(e)=>setRoomnumber(e.target.value)}/>
                                    <br/>
                                    <label htmlfor="aantalStoelen">Aantal Stoelen:</label><br />
                                    <input type="number" id="aantalStoelen" autoComplete="off" onChange={(e) => setCapaciteit(e.target.value)} required />
                                    <button className="btn">Zaal toevoegen</button>
                                </form>
                            </>
                                
                        ) : (
                            <>{/*Selecteer een zaal*/}
                                <Alinea titel="Kies een optie." />
                            </>
                            
                        )}
                    </>
                ):(
                    <>
                        {addZaal === 2 ? (
                            <>{/*Ruimte toevoegen */}
                                <h3>Ruimte toevoegen:</h3>
                                <form onSubmit={handleSubmit}>
                                    <label htmlfor="ruimtenaam">Ruimtenaam:</label><br />
                                    <input type="text" id="ruimtenaam" autoComplete="off" onChange={(e) => setRoomname(e.target.value)} required />
                                    <br />
                                    <label htmlfor="capaciteit">Capaciteit:</label><br />
                                    <input type="number" id="capaciteit" autoComplete="off" onChange={(e) => setCapaciteit(e.target.value)} required />
                                    <button className="btn">Ruimte toevoegen</button>
                                </form>
                            </>
                        ) : (
                            <>{/*By default this could only be accessed when addZaal===3 */}
                                <h3>Rij toevoegen:</h3>
                                <form onSubmit={handleSubmit}>
                                    <label htmlfor="rang">Rangnummer:</label><br/>
                                    <input type="number" id="rang" autoComplete="off" onChange={(e)=>setRangnummer(e.target.value)} required/>
                                    <br/>
                                    <label htmlFor="zaalnummer">Zaalnummer:</label>
                                    <input type="number" id="zaalnummer" autoComplete="off" onChange={(e)=>setRijZaal(e.target.value)} required/>
                                    <br/>
                                    <label htmlFor="rijcapaciteit">Aantal stoelen:</label>
                                    <input type="number" id="rijcapaciteit" autoComplete="off" onChange={(e)=>setRijCapaciteit(e.target.value)} required/>
                                    <button className="btn">Rij toevoegen</button>
                                </form>
                            </>
                        )}
                    </>
                )}
            </section>   
        </>
    );
}


export default ZaalToevoegen;