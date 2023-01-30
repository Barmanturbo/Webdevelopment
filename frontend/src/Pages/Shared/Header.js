import React, { useState } from "react";

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
                        <li role="menuitem"><a href="/">Home</a></li>
                        <li role="menuitem"><a href="/Programma">Programma</a></li>
                        <li role="menuitem"><a href="/OverOns">Over ons</a></li>
                        <li role="menuitem"><a href="/Huren">Huur</a></li>
                        <li role="menuitem"><a href="/Account">Mijn account</a></li>
                        <li role="menuitem"><a href="/Winkelmand"><i className="fa-solid fa-basket-shopping"></i></a></li>
                        <li role="menuitem"><a href="/Accesibility"><i className="fa fa-wheelchair" /></a></li>
                    </ul>
                </div>
            </nav>
        </header>
    );
}

export default Header;
