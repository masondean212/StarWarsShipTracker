import React, { useState, useEffect } from "react";
import { Button, Spinner, Table } from "reactstrap";
import { useNavigate } from "react-router-dom";
import api from "../utils/api";
import _ from "lodash";

function ShipList({adminRoute}) {
  const [shipList, setShipList] = useState([{}]);
  const [isLoading, setIsLoading] = useState(false);

  const navigate = useNavigate();
  const isAdminRoute = adminRoute === true;

  async function getShipList() {
    setIsLoading(true);
    await api
      .fetch("ship/getshiplist")
      .then((res) => setShipList(res))
      .finally(setIsLoading(false));
  }

  function displayActionsAdmin(id) {
    return(
    <>
      <Button color="caution" onClick={() => navigate(`/admin/edit-ship/${id}`)} >
        Edit
      </Button>
    </>)
  }

  useEffect(() => {
    getShipList();
  }, []);

  return (
    <>
      {isAdminRoute ? (<div className="d-flex justify-content-between mb-3">
        <h2>Users</h2>
        <Button color="primary" onClick={() => navigate("/admin/edit-ship/0")}>
          Add New
        </Button>
      </div>) : null}
      {isLoading ? (
        <Spinner />
      ) : (
        <Table>
          <thead>
            <tr>
              <th>Ship List</th>
              <th>Tier</th>
              <th>Actions</th>
            </tr>
          </thead>
          <tbody>
          {_.map(shipList, (item) => (
                    <tr key={item.id}>
                      <td>{item.name}</td>
                      <td>{item.tier}</td>
                      <td>{displayActionsAdmin(item.id)}</td>
                    </tr>
                  ))}
          </tbody>
        </Table>
      )}
    </>
  );
}

export default ShipList;
