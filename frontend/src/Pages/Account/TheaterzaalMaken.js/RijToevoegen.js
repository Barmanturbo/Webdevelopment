import React, { useState } from 'react';

const RijToevoegen = () => {
    const [elementID, setElementID] = useState(0)

    const [rangnummer, setRangnummer] = useState(0);
    const [rijZaal, setRijZaal] = useState(0);
    const [rijCapaciteit, setRijCapaciteit] = useState(0);

    const [success, setSuccess] = useState(false);

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            let res = await fetch("https://localhost:7214/api/Stoelrij", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify({
                    rijid: elementID,
                    Rangnummer: rangnummer,
                    Aantal_stoelen: rijCapaciteit,
                    Zaalnr: rijZaal
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

    return (<>
        <h3>Rij toevoegen:</h3>
        <form onSubmit={handleSubmit}>
            <label htmlfor="rang">Rangnummer:</label><br />
            <input type="number" id="rang" autoComplete="off" onChange={(e) => setRangnummer(e.target.value)} required />
            <br />
            <label htmlFor="zaalnummer">Zaalnummer:</label><br />
            <input type="number" id="zaalnummer" autoComplete="off" onChange={(e) => setRijZaal(e.target.value)} required />
            <br />
            <label htmlFor="rijcapaciteit">Aantal stoelen:</label><br />
            <input type="number" id="rijcapaciteit" autoComplete="off" onChange={(e) => setRijCapaciteit(e.target.value)} required />
            <br />
            <label htmlfor="rijid">Rij ID:</label><br />
            <input type="number" id="rijid" autoComplete="off" onChange={(e) => setElementID(e.target.value)} required />
            <button className="btn">Rij toevoegen</button>
        </form>
    </>)
}
export default RijToevoegen;