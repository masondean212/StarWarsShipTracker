import React, { useEffect, useState } from "react";
import { Badge, Button, Spinner, Table } from "reactstrap";
import api from "../utils/api";
import { useNavigate } from "react-router-dom";
import _ from "lodash";

function UserList() {
  const [isLoading, setIsLoading] = useState(false);
  const [users, setUsers] = useState([]);

  const navigate = useNavigate();

  useEffect(() => {
    setIsLoading(true);
    api
      .fetch("users/list")
      .then((users) => setUsers(users))
      .finally(() => setIsLoading(false));
  }, []);

  return (
    <>
      <div className="d-flex justify-content-between mb-3">
        <h2>Users</h2>
        <Button color="primary" onClick={() => navigate("/admin/create-user")}>
          Add New
        </Button>
      </div>
      {isLoading ? (
        <Spinner />
      ) : (
        <Table>
          <thead>
            <tr>
              <th>Username</th>
              <th>Roles</th>
              <th></th>
            </tr>
          </thead>
          <tbody>
            {_.map(users,u => (
              <tr key={u.id}>
                <td>{u.username}</td>
                <td>
                  {_.map(u.roles,r => (
                    <Badge key={r.id}>{r.name}</Badge>
                  ))}
                </td>
                <td></td>
              </tr>
            ))}
          </tbody>
        </Table>
      )}
    </>
  );
}

export default UserList;
