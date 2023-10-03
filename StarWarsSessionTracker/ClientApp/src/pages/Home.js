import React, { useState, useEffect } from 'react';
import api from '../utils/api';
import _ from 'lodash';
import { Col, Row } from 'reactstrap';
import AbilityScores from '../components/AbilityScores';
import ArmorBonus from '../components/ArmorBonus';
import Shield from '../components/Shield';

function Home() {

  const [isLoading, setLoading] = useState(true);
  const [currentShip, setCurrentShip] = useState([{}]);


  useEffect(() => {
    setLoading(true);
    api.fetch('ship/getCurrentShip')
      .then(res => setCurrentShip(res))
      .then(() => console.log(currentShip))
      .then(() => setLoading(false))
  }, []);

  return (<>{isLoading ? <div>LOADING</div> : (
    <div>
      <h1>{currentShip.name}</h1>
      <Row>
        <Col>
          <AbilityScores
            abilityScoreList={{
              strength: currentShip.strength,
              dexterity: currentShip.dexterity,
              constitution: currentShip.constitution,
              intelligence: currentShip.intelligence,
              wisdom: currentShip.wisdom,
              charisma: currentShip.charisma
            }}
            skillList={currentShip.skills}
            tier={currentShip.tier} />
        </Col>
        <Col>
          <Row>
            <ArmorBonus
              armorPartDetails={currentShip.armor}
              dexterityScore={currentShip.dexterity} />
          </Row>
          <Row>
            <Shield
              shieldPartDetails={currentShip.shield}
              //shieldCurrentStats={}
            />
          </Row>
        </Col>
      </Row>
    </div>)}
  </>);
}

export default Home;
