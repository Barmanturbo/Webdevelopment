import React, { useEffect } from 'react';
import Alinea from '../Shared/Alinea';

const IkDoneer = (props) => {

    var details = {
        "amount": props.bedrag,
        'reference': '123456789', 
        'url': '',
    };

    var formBody = [];
    for (var property in details) {
        var encodedKey = encodeURIComponent(property);
        var encodedValue = encodeURIComponent(details[property]);
        formBody.push(encodedKey + "=" + encodedValue);
    }
    formBody = formBody.join("&");

    const [html, setHTML] = "";
    let code = `${html}`;

    useEffect(() => {
        fetch('https://ikdoneer.azurewebsites.net/', {
            method: 'POST',
            headers:{
                Authorization: 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIzMWNjM2RjYi1kZmU0LTQ2Y2QtYjBmNC04MmZlMzlhNWE2ZjAiLCJqdGkiOiIzZjg0ZmIzOS02N2RmLTRkMWEtYjk4OS02MTkyMWNkMzQ2YTYiLCJpYXQiOiIwMS8yOS8yMDIzIDIxOjA2OjM3IiwiVXNlcklkIjoiMzFjYzNkY2ItZGZlNC00NmNkLWIwZjQtODJmZTM5YTVhNmYwIiwiRW1haWwiOiIyMTAzNTQwN0BzdHVkZW50Lmhocy5ubCIsImV4cCI6MTk5MDY0NTU5NywiaXNzIjoiSWtEb25lZXIiLCJhdWQiOiIqIn0.vu-4QGq2GgPC-l9Ib-DVKpOq69dwDVSQM6Co8qOCVa0',
                'Accept': 'application/x-www-form-urlencoded;charset=UTF-8',
                'Content-Type': 'application/x-www-form-urlencoded;charset=UTF-8',
                'Access-Control-Allow-Origin': '*'
            },    
            body: formBody
        })
            .then(response => {
            return response.text();
        })
            .then(response => {
            return setHTML(response);
        })
    });

    if (html === undefined || html === ""){
        return (
            <Alinea titel="Oeps er is iets mis gegaan" 
            tekst="Probeer het later nog eens"
            link="/"
            linknaam="Ga terug naar de homepagina"/>
        )
    }else{
        return (
            <section className='contact'>
                <div dangerouslySetInnerHTML={{ __html: code}}/>
            </section>
        );
    }
}

export default IkDoneer;