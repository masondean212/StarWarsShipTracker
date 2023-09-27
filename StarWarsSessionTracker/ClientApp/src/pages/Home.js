import React, { useState , useEffect} from 'react';
import api from '../utils/api';
import _ from 'lodash';
import { Col , Row } from 'reactstrap';
import { AbilityScores } from '../components/ShipCharacterSheet';

function Home() {

  const [shipList, setShipList] = useState([{}]);
  async function getShipList() {
    await api.fetch('ship/getshiplist')
      .then(res => setShipList(_.map(res, ship => { return { value: ship.id, label: ship.name } })))
  }

  useEffect(() => getShipList, []);

  return (
    <div>
      <h1>SHIPNAME</h1>
      <Row>
        <Col>
          <AbilityScores />
        </Col>
      </Row>
    </div>
  );
}

export default Home;
