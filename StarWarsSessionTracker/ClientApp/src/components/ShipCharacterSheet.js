import React from 'react';
import { Col, Row, Card } from 'reactstrap';
import _ from 'lodash';

var profBonus = 0 + 2;

function AbilityScore(scoreName, scoreValue, skillList) {
    console.log(skillList)
    var value = Math.floor((scoreValue - 10)/2);
    return (<Row>
        <Col>
            <Card>
                <Row>
                    {value}
                </Row>
                <Row>
                    {scoreValue}
                </Row>
            </Card>
        </Col>
        <Col>
            <Row>{scoreName}</Row>
            <Row>
            <table><tbody>
            {_.map(skillList, (item,i) => <tr key={i}><td>{item.proficiency}</td><td>{item.proficiency*profBonus + value}</td><td>{item.skill}</td></tr>)}
            </tbody></table>
            </Row>
        </Col>
    </Row>);
}

function AbilityScores() {
    var abilitiesFromAPI = { Strength: 10, Dexterity: 12, Constitution: 16, Intelligence: 14, Wisdom: 8, Charisma: 18 };
    return (<Card>
            {AbilityScore("Strength",abilitiesFromAPI.Strength,[{skill: "Boost", proficiency: 1},{skill: "Ram", proficiency: 0}])}
            {AbilityScore("Dexterity",abilitiesFromAPI.Dexterity,[{skill: "Hide", proficiency: 0},{skill: "Manuevering", proficiency: 0}])}
            {AbilityScore("Constitution",abilitiesFromAPI.Constitution,[{skill: "Patch", proficiency: 1},{skill: "Regulation", proficiency: 0}])}
            {AbilityScore("Intelligence",abilitiesFromAPI.Intelligence,[{skill: "Astrogation", proficiency: 1},{skill: "Data", proficiency: 0},{skill: "Probe", proficiency: 2}])}
            {AbilityScore("Wisdom",abilitiesFromAPI.Wisdom,[{skill: "Scan", proficiency: 1}])}
            {AbilityScore("Charisma",abilitiesFromAPI.Charisma,[{skill: "Impress", proficiency: 1},{skill: "Interfere", proficiency: 2},{skill: "Menace", proficiency: 0},{skill: "Swindle", proficiency: 0}])}
    </Card>);
}

export { AbilityScores };