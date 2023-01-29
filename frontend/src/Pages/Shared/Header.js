import React, { useState } from "react";
import { MenuItem } from "react-bootstrap";

const Header = () => {
    const [isMenuOpen, setIsMenuOpen] = useState(false);

    return (
        <header>
            <nav className="navigation">
                <h3>&nbsp;<a href="/">Laaktheater</a></h3>
                <button className="icon" onClick={
                    () => { setIsMenuOpen(!isMenuOpen); }
                }
                ><i className="fa fa-bars"></i></button>
                <div className={isMenuOpen ? "menu open" : "menu"}>
                    <ul role="menubar" aria-label="Menu balk">
                        <li><a href="/">Home</a></li>
                        <li ><a href="/Programma" role="menuitem">Programma</a></li>
                        <li><a href="/OverOns" role="menuitem">Over ons</a></li>
                        <li><a href="/Huren" role="menuitem">Huur</a></li>
                        <li><a href="/Account" role="menuitem">Mijn account</a></li>
                        <li><a href="/Winkelmand" role="menuitem"><i className="fa-solid fa-basket-shopping"></i></a></li>
                        <li><a href="/Accesibility" role="menuitem"><i className="fa fa-wheelchair" /></a></li>
                    </ul>
                </div>
            </nav>
        </header>
    );
}

export default Header;
