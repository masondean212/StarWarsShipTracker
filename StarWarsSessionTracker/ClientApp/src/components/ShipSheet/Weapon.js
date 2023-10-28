import React, { useState } from 'react';
import { Row, Col, Modal, ModalBody, ModalHeader, Button, Container } from 'reactstrap';
import { getModifierFromScore, valueAddPlusIfPositive } from '../../utils/functions';
import _ from 'lodash'

function Weapon({ weaponList, strength, wisdom }) {

    let wisdomMod = getModifierFromScore(wisdom);
    let strengthMod = getModifierFromScore(strength);

    function convertDamage() {
        if (strengthMod < 0) {
            return " - " + Math.abs(strengthMod);
        }
        else if (strengthMod === 0) {
            return "";
        }
        else {
            return " + " + strengthMod
        }
    }
    function DisplayProperty(prop, i, propertyCount) {
        const [modal, setModal] = useState(false);
        const toggle = () => setModal(!modal);

        function getPropertyName() {
            if (prop.modifierValue === 0) {
                return prop.name;
            }
            else {
                return prop.name + " " + prop.modifierValue;
            }
        }
        function getListItemFormat() {
            if (i < propertyCount - 1) {
                return getPropertyName() + ", ";
            }
            else {
                return getPropertyName();
            }
        }
        return (<>
            <span onClick={toggle}>{getListItemFormat()}</span>
            <Modal isOpen={modal} toggle={toggle} >
                <ModalHeader>{getPropertyName()}</ModalHeader>
                <ModalBody>{prop.description}</ModalBody>
                <Button color="secondary" onClick={toggle}>
                    Close
                </Button>
            </Modal>
        </>)
    }
    function displayWeapon(weapon, i) {

        var propertyCount = weapon.properties.length;
        return (<Container key={i} className="square border mb-2 rounded-1">
            <Row>
                <Col className="square border-end">
                    <Row className="mb-0 text-muted ps-1"
                        tag="h6"
                        style={{ fontSize: "10px" }}>
                        Weapon
                    </Row>
                    <Row className="ps-2">
                        {weapon.name}
                    </Row>
                </Col>
                <Col className="square border-end">
                    <Row className="mb-0 text-muted ps-1"
                        tag="h6"
                        style={{ fontSize: "10px" }}>
                        Atk Bonus
                    </Row>
                    <Row className="ps-2">
                        {valueAddPlusIfPositive(wisdomMod)}
                    </Row>
                </Col>
                <Col>
                    <Row className="mb-0 text-muted ps-1"
                        tag="h6"
                        style={{ fontSize: "10px" }}>
                        Damage
                    </Row>
                    <Row className="ps-2">
                        {weapon.damage + convertDamage() + " " + weapon.damageType}
                    </Row>
                </Col>
            </Row>
            <Row className="square border-top">
                <Col>
                    <Row className="mb-0 text-muted ps-1"
                        tag="h6"
                        style={{ fontSize: "10px" }}>
                        Properties
                    </Row>
                    {_.map(weapon.properties, (prop, i) => DisplayProperty(prop, i, propertyCount))}
                </Col>
            </Row>
        </Container>)
    }

    return (<>
        {_.map(weaponList, (weapon, i) => displayWeapon(weapon, i))}
    </>);
}


export default Weapon;