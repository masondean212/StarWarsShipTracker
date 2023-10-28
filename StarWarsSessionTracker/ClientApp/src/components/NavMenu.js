import React, { useState } from "react";
import {
  Collapse,
  Navbar,
  NavbarBrand,
  NavbarToggler,
  NavItem,
  NavLink,
} from "reactstrap";
import { Link } from "react-router-dom";
import "./NavMenu.css";
import useAuth from "../hooks/useAuth";

function NavMenu() {
  const [navbar, toggleNavbar] = useState(true);
  const logOut = useAuth((x) => x.clearData);
  const currentUser = useAuth((x) => x.currentUser);
  const isAdmin = currentUser?.roles?.some((x) => x.name === "Admin");
  return (
    <header>
      <Navbar
        className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3"
        container
        light
      >
        <NavbarBrand tag={Link} to="/">
          Star Wars Ship Tracker
        </NavbarBrand>
        <NavbarToggler onClick={() => toggleNavbar(!navbar)} className="mr-2" />
        <Collapse
          className="d-sm-inline-flex flex-sm-row-reverse"
          isOpen={!navbar}
          navbar
        >
          <ul className="navbar-nav flex-grow">
            <NavItem>
              <NavLink tag={Link} className="text-dark" to="/">
                Home
              </NavLink>
            </NavItem>
            <NavItem>
              <NavLink tag={Link} className="text-dark" to="/ship-inventory">
                Ship Inventory
              </NavLink>
            </NavItem>
            <NavItem>
              <NavLink tag={Link} className="text-dark" to="/ship-list">
                Ship List
              </NavLink>
            </NavItem>
            {isAdmin ? (
            <NavItem>
              <NavLink tag={Link} className="text-dark" to="/admin">
                Admin
              </NavLink>
            </NavItem> ) : null}
            <NavItem>
              <NavLink
                tag={Link}
                className="text-dark"
                to="/"
                onClick={() => logOut()}
              >
                Logout
              </NavLink>
            </NavItem>
          </ul>
        </Collapse>
      </Navbar>
    </header>
  );
}

export default NavMenu;
