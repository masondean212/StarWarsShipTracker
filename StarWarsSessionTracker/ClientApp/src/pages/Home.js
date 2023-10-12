import React, { useState, useEffect } from 'react';
import api from '../utils/api';
import _ from 'lodash';
import { Col, Row } from 'reactstrap';
import AbilityScores from '../components/AbilityScores';
import ArmorBonus from '../components/ArmorBonus';
import HealthOrShields from '../components/HealthOrShields';
import Weapon from '../components/Weapon';

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
        <Col xs="4" className="pb-2">
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
            <Col>
              <Row>
                <ArmorBonus
                  armorPartDetails={currentShip.armor}
                  dexterityScore={currentShip.dexterity} />
              </Row>
            </Col>
            <Col>Test</Col>
          </Row>
          <Row>
            <Col className="px-3">
              <HealthOrShields
                partDetails={{
                  name: currentShip.shield.name,
                  modifier: currentShip.shield.shieldCapacity
                }}
                currentStats={{
                  currentPoints: currentShip.currentShieldPoints,
                  rolledPoints: currentShip.rolledShieldPoints,
                  temporaryPoints: currentShip.temporaryShieldPoints,
                }}
                abilityScore={currentShip.strength}
                type="SHIELD"
              />
            </Col>
            <Col className="px-3">
              <HealthOrShields
                partDetails={{
                  name: currentShip.shield.name,
                  modifier: 1
                }}
                currentStats={{
                  currentPoints: currentShip.currentHitPoints,
                  rolledPoints: currentShip.rolledHitPoints,
                  temporaryPoints: currentShip.temporaryHitPoints,
                }}
                abilityScore={currentShip.constitution}
                type="HIT"
              />
            </Col>
          </Row>
          <Weapon 
            weaponList={currentShip.weapons}
            wisdom={currentShip.wisdom}
            strength={currentShip.strength}/>
        </Col>
      </Row >
    </div >)
  }
  </>);
}

export default Home;
