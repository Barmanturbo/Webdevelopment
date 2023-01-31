import React, { useState } from 'react';

const RuimteToevoegen = () => {
    const [roomname, setRoomname] = useState("");
    const [roomnumber, setRoomnumber] = useState(0);
    const [capaciteit, setCapaciteit] = useState("");

    const [success, setSuccess] = useState(false);

    const handleSubmit = async (e) => {
        try {
            let res = await fetch("https://localhost:7214/api/Ruimte", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify({
                    RuimteNR: roomnumber,
                    Naam: roomname,
                    Capaciteit: capaciteit
                }),
            })
            if (res.status === 200) {
                setSuccess(true);
                console.log("success");
                console.log(success);
            }
        } catch (err) {
            console.log(err);
        }
    }

    return (<><h3>Ruimte toevoegen:</h3>
        <form onSubmit={handleSubmit}>
            <label htmlfor="ruimtenaam">Ruimtenaam:</label><br />
            <input type="text" id="ruimtenaam" autoComplete="off" onChange={(e) => setRoomname(e.target.value)} required />
            <br />
            <label htmlfor="ruimteid">Ruimte nummer:</label><br />
            <input type="number" id="ruimteid" autoComplete="off" onChange={(e) => setRoomnumber(e.target.value)} required />
            <br />
            <label htmlfor="capaciteit">Capaciteit:</label><br />
            <input type="number" id="capaciteit" autoComplete="off" onChange={(e) => setCapaciteit(e.target.value)} required />
            <button className="btn">Ruimte toevoegen</button>
        </form></>);
}


export default RuimteToevoegen;