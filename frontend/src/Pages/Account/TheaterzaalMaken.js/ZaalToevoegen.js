import React, { useState } from 'react';
const ZaalToevoegen = () => {
    const [roomname, setRoomname] = useState("");
    const [roomnumber, setRoomnumber] = useState(0);
    const [capaciteit, setCapaciteit] = useState("");

    const [success, setSuccess] = useState(false);

    const handleSubmit = async (e) => {
        try {
            e.preventDefault();
            let res = await fetch("https://localhost:7214/api/Zaal", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify({
                    Zaalnr: roomnumber,
                    Naam: roomname,
                    Aantal_stoelen: capaciteit
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

    return (<><h3>Zaal toevoegen:</h3>
        <form onSubmit={handleSubmit}>
            <label htmlfor="zaalnaam">Zaalnaam:</label><br />
            <input type="text" id="zaalnaam" autoComplete="off" onChange={(e) => setRoomname(e.target.value)} required />
            <br />
            <label htmlfor="zaalnummer">Zaalnummer:</label><br />
            <input type="number" id="zaalnummer" autoComplete="off" onChange={(e) => setRoomnumber(e.target.value)} />
            <br />
            <label htmlfor="aantalStoelen">Aantal Stoelen:</label><br />
            <input type="number" id="aantalStoelen" autoComplete="off" onChange={(e) => setCapaciteit(e.target.value)} required />
            <button className="btn">Zaal toevoegen</button>
        </form>
    </>);
}
export default ZaalToevoegen;