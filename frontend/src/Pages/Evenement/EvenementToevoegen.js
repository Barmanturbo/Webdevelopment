import React from 'react';
import Hero2 from '../Shared/Hero2';
import { useState } from "react";
import {DayPicker} from "react-day-picker";

const EvenementToevoegen = (props) => {
    const [formData, setFormData] = useState();
    const [days, setDays] = useState;

    //e staat voor event
    const handleChange = (e) => {
        setFormData(e.target.value);
    }

    const handleSubmit = (e) => {
        e.preventDefault();
        alert(formData);
    }

    return (
        <>
            <Hero2 tekst="Evenement Toevoegen" />
                
            <section className="contact">
             <form>
                <p>Naam evenement</p>
                <input type="text" placeholder={props.tekst} onChange={handleChange}/>
                <p>Zaal</p>

                <p>Dagen</p>
                <Daypicker
                    mode="multiple"
                    min={1}
                    // Willen we hier nog een max toevoegen?
                    selected={days}
                    onSelect={setDays}
                ></Daypicker>

                <button className="btn" onClick={handleSubmit}> Submit </button>
            </form>
            </section>   
        </>
    );
}

export default EvenementToevoegen;