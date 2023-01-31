import React, { useState }  from 'react';
import Alinea from '../Shared/Alinea';
import Hero2 from '../Shared/Hero2';
import ZaalToevoegen from './TheaterzaalMaken.js/ZaalToevoegen';
import RuimteToevoegen from './TheaterzaalMaken.js/RuimteToevoegen';
import RijToevoegen from './TheaterzaalMaken.js/RijToevoegen';

const Admin = () => {
    const [addZaal, setAddZaal] = useState("");

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

    function updateDiv(){
        
    }

    const handleSubmit = async (e) => {
        e.preventDefault();
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
                    <option value="0" disabled selected>Selecteer een zaal</option>
                    <option value="1">Zaal toevoegen</option>
                    <option value="2">Ruimte toevoegen</option>
                    <option value="3">Rij toevoegen</option>
                </select>
                <div id="formcontainer">
                {addZaal!=2||addZaal!=3?(
                    <>{/*checks for only legal values */}
                        { addZaal=== 1?(
                            <>
                            <ZaalToevoegen/>
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
                            <>
                            <RuimteToevoegen/>
                            </>
                        ) : (
                            <>{/*By default this could only be accessed when addZaal===3 */}
                            <RijToevoegen/>
                            </>
                        )}
                    </>
                )}</div>
            </section>
            </>)}   
        </>
    );
}


export default Admin;