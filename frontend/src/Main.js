import React from "react";
import { Routes, Route, BrowserRouter } from "react-router-dom";
import Home from "./Pages/Home/Home";
import About from "./Pages/OverOns/OverOns";
import Winkelmand from "./Pages/Winkelmand/Winkelmand";
import Programma from "./Pages/Programma/Programma";
import Accesibility from "./Pages/Accesibility/Accesibility";
import Voorwaarden from "./Pages/Voorwaarden/Voorwaarden";
import VierNulVier from "./Pages/404/404";
import Show from "./Pages/Show/Show";
import Login from "./Pages/Account/Login";
import Account from "./Pages/Account/Account";
import Aanmaken from "./Pages/Account/Aanmaken";
import Huren from "./Pages/Winkelmand/Huren";
import Doneren from "./Pages/Account/Doneren";
import ShowToevoegen from "./Pages/Show/ShowToevoegen";
import Admin from "./Pages/Account/Admin";

class Main extends React.Component {
  render() {
    return (
      <BrowserRouter>
          <Routes>
            <Route exact path="/" element={<Home />} />
            <Route path="/Overons" element={<About />} />
            <Route path="/Winkelmand" element={<Winkelmand />} />
            <Route path="/Programma" element={<Programma />} />
            <Route path="/Show" element={<Show/>} />
            <Route path="/Accesibility" element={<Accesibility />} />
            <Route path="/Voorwaarden" element={<Voorwaarden />} />
            <Route path="/Login" element={<Login />} />
            <Route path="/Account" element={<Account />} />
            <Route path="/Aanmaken" element={<Aanmaken />} />
            <Route path="/ShowToevoegen" element={<ShowToevoegen />} />
            <Route path="/Huren" element={<Huren />} />
            <Route path="/Doneren" element={<Doneren />} />
            <Route path="/Admin" element={<Admin/>}/>
            <Route path="*" element={<VierNulVier />} />
          </Routes>
      </BrowserRouter>
    );
  }
}

export default Main;