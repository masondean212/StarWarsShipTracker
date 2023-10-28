import React, { useState, useEffect } from "react";
import api from "../utils/api";
import _ from "lodash";
import { Col, Row, Container, Card, Input } from "reactstrap";
import {useParams} from "react-router-dom"

function ModifyShip() {
  const [isLoading, setLoading] = useState(true);
  const [currentShip, setCurrentShip] = useState([{}]);
  const {shipId} = useParams();

  useEffect(() => {
    if (shipId != 0) {
      setLoading(true);
      api
        .fetch("ship/getCurrentShip")
        .then((res) => setCurrentShip(res))
        .then(() => console.log(currentShip))
        .then(() => setLoading(false));
    }
  }, []);
 useEffect(()=> console.log(currentShip),[currentShip]);
  return (
    <Container>
      <Row>
        <Col>
          <Card body>
                <Row className="m-auto">
                    Strength
                </Row>
                <Row tag="h2" className="m-auto">
                  <Input 
                    onChange={(e)=>{setCurrentShip({...currentShip,strength: e.target.value})}}
                    value={currentShip.strength} />
                </Row>
          </Card>
        </Col>
        <Col>
        <Card body>
                <Row className="m-auto">
                    Dexterity
                </Row>
                <Row tag="h2" className="m-auto">
                  <Input 
                    onChange={(e)=>{setCurrentShip({...currentShip,Dexterity: e.target.value})}}
                    value={currentShip.Dexterity} />
                </Row>
            </Card>
        </Col>
      </Row>
    </Container>)
}

export default ModifyShip;
