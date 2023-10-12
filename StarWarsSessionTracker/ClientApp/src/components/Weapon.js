import React from 'react';
import { Row, Col } from 'reactstrap';
import { getModifierFromScore } from '../utils/functions';
import _ from 'lodash'

function Weapon({ weaponList, strength, wisdom }) {

    let wisdomMod = getModifierFromScore(wisdom);
    let strengthMod = getModifierFromScore(strength);
    function convertAttack() {
        if (wisdomMod < 0) {
            return wisdomMod;
        }
        else {
            return "+" + wisdomMod;
        }
    }
    function convertDamage() {
        if (strengthMod < 0) {
            return " - " + Math.abs(strengthMod);
        }
        else if (strengthMod == 0) {
            return "";
        }
        else {
            return " + " + strengthMod
        }
    }
    function displayWeapon(weapon, i) {

        return (<div key={i}><Row>
            <Col>{weapon.name}</Col>
            <Col>{convertAttack()}</Col>
            <Col>{weapon.damage + convertDamage() + " " + weapon.damageType}</Col>
        </Row>
            <Row>
                <Col>{weapon.properties}</Col>
            </Row></div>)
    }

    return (<>
        {_.map(weaponList, (weapon, i) => displayWeapon(weapon, i))}
    </>);
}

export default Weapon;