import React, { useState }  from 'react';
import Alinea from '../Shared/Alinea';
import Hero2 from '../Shared/Hero2';

const Admin = () => {
    const [addZaal, setAddZaal] = useState(0);

    const [roomname, setRoomname] = useState("");
    const [roomnumber, setRoomnumber] = useState(0);
    const [capaciteit,setCapaciteit] = useState("");
    
    const [elementID, setElementID] = useState(0)

    const [rangnummer, setRangnummer] = useState(0);
    const [rijZaal, setRijZaal] = useState(0);
    const [rijCapaciteit, setRijCapaciteit] = useState(0);

    const [success, setSuccess]= useState(false);

    const clearValues = ()=>{
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

    const handleSubmit = async(e)=>{
        e.preventDefault();

        try{
            let res;
            if(addZaal===1){
                res = await fetch("https://localhost:7214/api/Zaal",{
                    method: "POST",
                    headers: {
                        "Content-Type":"application/json",
                    },
                    body: JSON.stringify({
                        Zaalnr: roomnumber,
                        Naam: roomname,
                        Aantal_stoelen: capaciteit
                    }),
                })
            }else{
                if(addZaal===2){
                    res = await fetch("https://localhost:7214/api/Ruimte",{
                        method: "POST",
                        headers: {
                            "Content-Type":"application/json",
                        },
                        body: JSON.stringify({
                            RuimteNR: roomnumber,
                            Naam: roomname,
                            Capaciteit: capaciteit
                        }),
                    })
                }else{
                    if(addZaal===3){
                        res = await fetch("https://localhost:7214/api/Stoelrij",{
                        method: "POST",
                        headers: {
                            "Content-Type":"application/json",
                        },
                        body: JSON.stringify({
                            rijid: elementID,
                            Rangnummer: rangnummer,
                            Aantal_stoelen: rijCapaciteit,
                            Zaalnr: rijZaal
                        }),
                    })
                    }else{
                        throw "Invalid option. Choose a valid option"
                    }
                }
            }
            if(res.status===200){
                setSuccess(true);
                console.log("success")
            }
        }catch(err){
            console.log(err);
        }
    }


    return (
        <>{success?(
            <>
            <Hero2 tekst="Zalen configureren"/>
            <Alinea teksts="Zaal met succes toegevoegd."/>
            <button className="btn" onClick={(e)=>clearValues()}>Nog een zaal toevoegen?</button>
            </>
        ):(
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
                                    <label htmlfor="ruimteid">Ruimte nummer:</label><br/>
                                    <input type="number" id="ruimteid" autoComplete="off" onChange={(e) => setRoomnumber(e.target.value)} required />
                                    <br/>
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
                                    <label htmlFor="zaalnummer">Zaalnummer:</label><br/>
                                    <input type="number" id="zaalnummer" autoComplete="off" onChange={(e)=>setRijZaal(e.target.value)} required/>
                                    <br/>
                                    <label htmlFor="rijcapaciteit">Aantal stoelen:</label><br/>
                                    <input type="number" id="rijcapaciteit" autoComplete="off" onChange={(e)=>setRijCapaciteit(e.target.value)} required/>
                                    <br/>
                                    <label htmlfor="rijid">Rij ID:</label><br />
                                    <input type="number" id="rijid" autoComplete="off" onChange={(e) => setElementID(e.target.value)} required />
                                    <button className="btn">Rij toevoegen</button>
                                </form>
                            </>
                        )}
                    </>
                )}
            </section>
            </>)}   
        </>
    );
}


export default Admin;