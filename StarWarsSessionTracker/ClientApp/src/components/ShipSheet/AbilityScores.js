import React from 'react';
import { Col, Row, Card } from 'reactstrap';
import _ from 'lodash';
import { getModifierFromScore, valueAddPlusIfPositive } from '../../utils/functions';
import GeneralSkillList from '../../storage/GeneralSkillList';

function getSkillListFromGeneral(scoreName, generalSkillsForAbility, shipSkillList) {
    return _.map(generalSkillsForAbility, skill => getSkillDetails(scoreName,skill, shipSkillList))
}

function getSkillDetails(scoreName,skill, shipSkillList) {
    let shipSkill = _.find(shipSkillList, {name: skill, ability: scoreName})
    if (shipSkill) {
        return shipSkill;
    }
    else {
        return { name: skill, proficiency: 0 }
    }
}

function AbilityScore(scoreName, scoreValue, skillList, tier) {

    let profBonus = tier + 2;
    let value = getModifierFromScore(scoreValue);
    let savingThrowDetails = getSkillDetails(scoreName,"Saving Throw",skillList);
    let finalSkillList;
    switch (scoreName) {
        case "Strength": finalSkillList = getSkillListFromGeneral(scoreName, GeneralSkillList.strength, skillList); break;
        case "Dexterity": finalSkillList = getSkillListFromGeneral(scoreName, GeneralSkillList.dexterity, skillList); break;
        case "Constitution": finalSkillList = getSkillListFromGeneral(scoreName, GeneralSkillList.constitution, skillList); break;
        case "Intelligence": finalSkillList = getSkillListFromGeneral(scoreName, GeneralSkillList.intelligence, skillList); break;
        case "Wisdom": finalSkillList = getSkillListFromGeneral(scoreName, GeneralSkillList.wisdom, skillList); break;
        case "Charisma": finalSkillList = getSkillListFromGeneral(scoreName, GeneralSkillList.charisma, skillList); break;
        default: break;
    }


    function ProficiencyConvert(level) {
        switch (level) {
            case 0: return "N";
            case 1: return "P";
            case 2: return "E";
            default: return "N"
        }
    }

    return (<Row className="pb-2">
        <Col xs="4">
            <Card body>
                <Row tag="h2" className="m-auto">
                    {value}
                </Row>
                <Row className="m-auto">
                    {scoreValue}
                </Row>
            </Card>
        </Col>
        <Col className="p-0">
            <Row tag="strong" style={{ backgroundColor: "red", color: "white" }}><div>{scoreName.toUpperCase()}</div></Row>
            <Row>
                <table>
                    <tbody>
                        <tr key={0}>
                            <th style={{ width: "5%" }}>{ProficiencyConvert(savingThrowDetails.proficiency)}</th>
                            <th style={{ width: "5%" }}>{valueAddPlusIfPositive(savingThrowDetails.proficiency * profBonus + value)}</th>
                            <th style={{ width: "60%" }}>{"Saving Throw"}</th>
                        </tr>
                        {_.map(finalSkillList, (skill, i) =>
                            <tr key={i}>
                                <td style={{ width: "5%" }}>{ProficiencyConvert(skill.proficiency)}</td>
                                <td style={{ width: "5%" }}>{valueAddPlusIfPositive(skill.proficiency * profBonus + value)}</td>
                                <td style={{ width: "60%" }}>{skill.name}</td>
                            </tr>)}
                    </tbody>
                </table>
            </Row>
        </Col>
    </Row>);
}

function AbilityScores({ abilityScoreList, skillList, tier }) {
    return (<Card className="pe-4">
        {AbilityScore("Strength", abilityScoreList.strength, skillList, tier)}
        {AbilityScore("Dexterity", abilityScoreList.dexterity, skillList, tier)}
        {AbilityScore("Constitution", abilityScoreList.constitution, skillList, tier)}
        {AbilityScore("Intelligence", abilityScoreList.intelligence, skillList, tier)}
        {AbilityScore("Wisdom", abilityScoreList.wisdom, skillList, tier)}
        {AbilityScore("Charisma", abilityScoreList.charisma, skillList, tier)}
    </Card>);
}

export default AbilityScores;