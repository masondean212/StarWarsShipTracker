import React, { useState , useEffect } from 'react';
import api from '../utils/api';
import _ from 'lodash';

function ShipList() {

  const [shipList, setShipList] = useState([{}]);
  const [isLoading, setIsLoading] = useState(false);
  async function getShipList() {
    setIsLoading(true);
    await api.fetch('ship/getshiplist')
      .then(res => setShipList(res));
    setIsLoading(false);
  }

  useEffect(() => getShipList, []);
  
  return (
    <table className='table table-striped' aria-labelledby="tabelLabel">
      <thead>
        <tr>
          <th>Ship List</th>
          <th>Active</th>
        </tr>
      </thead>
      <tbody>
        {!isLoading ? _.map(item =>
          <tr key={shipList.id}>
            <td>{shipList.name}</td>
          </tr>
        ) : ""}
      </tbody>
    </table>
  );
}

export default ShipList;
