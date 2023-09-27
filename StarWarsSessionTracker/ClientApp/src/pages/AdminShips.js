import React from 'react';
import { NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';

function AdminShip() {

    return (<>
        <ul className="navbar-nav flex-grow">
              <NavItem>
                <NavLink tag={Link} className="text-dark" to="/admin/add-ship">Add Ship</NavLink>
              </NavItem>
              <NavItem>
                <NavLink tag={Link} className="text-dark" to="/admin/add-ship-feature">Add Features To Ship</NavLink>
              </NavItem>
              <NavItem>
                <NavLink tag={Link} className="text-dark" to="/admin/update-database">Update Database</NavLink>
              </NavItem>
            </ul>
    </>);
}

export default AdminShip;