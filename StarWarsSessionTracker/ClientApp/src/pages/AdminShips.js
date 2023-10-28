import React from 'react';
import { NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';

function AdminShip() {

    return (<>
        <ul className="navbar-nav flex-grow">
              <NavItem>
                <NavLink tag={Link} className="text-dark" to="/admin/ship-list">Manage Ships</NavLink>
              </NavItem>
              <NavItem>
                <NavLink tag={Link} className="text-dark" to="/admin/user-list">Manage Users</NavLink>
              </NavItem>
            </ul>
    </>);
}

export default AdminShip;