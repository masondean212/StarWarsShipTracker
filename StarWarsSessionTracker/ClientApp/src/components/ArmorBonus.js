import React from 'react';
import { Col, Row } from 'reactstrap';
import { getModifierFromScore } from '../utils/functions';
function ArmorBonus({ armorPartDetails , dexterityScore }) {

    function getArmorClass() {
        var possibleAC = 10 + getModifierFromScore(dexterityScore);
        return Math.min(armorPartDetails.maxAC, possibleAC);
    }
    return(<>
        <Row>
            <Col>{getArmorClass()}</Col>
            <Col>Armor Class</Col>
            <Col>{armorPartDetails.damageReduction}</Col>
            <Col>Damage Reduction</Col>
        </Row>
        <Row>
            <Col>
            </Col>
        </Row>
        <Row>
            <Col>Armor & Bonuses</Col>
        </Row>
    </>);
}

export default ArmorBonus;