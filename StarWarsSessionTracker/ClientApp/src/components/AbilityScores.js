import React, { useState } from 'react';
import { Col, Row, Card } from 'reactstrap';
import _ from 'lodash';
import { getModifierFromScore } from '../utils/functions';
import GeneralSkillList from '../storage/GeneralSkillList';

function getSkillListFromGeneral(scoreName, generalSkillsForAbility, shipSkillList) {
    console.log(shipSkillList)
    return _.map(generalSkillsForAbility, skill => getSkillDetails(scoreName,skill, shipSkillList))
}

function getSkillDetails(scoreName,skill, shipSkillList) {
    var shipSkill = _.find(shipSkillList, {name: skill, ability: scoreName})
    if (shipSkill) {
        return shipSkill;
    }
    else {
        return { name: skill, proficiency: 0 }
    }
}

function AbilityScore(scoreName, scoreValue, skillList, tier) {

    var profBonus = tier + 2;
    var value = getModifierFromScore(scoreValue);
    var savingThrowDetails = getSkillDetails(scoreName,"Saving Throw",skillList);
    switch (scoreName) {
        case "Strength": var finalSkillList = getSkillListFromGeneral(scoreName, GeneralSkillList.strength, skillList); break;
        case "Dexterity": var finalSkillList = getSkillListFromGeneral(scoreName, GeneralSkillList.dexterity, skillList); break;
        case "Constitution": var finalSkillList = getSkillListFromGeneral(scoreName, GeneralSkillList.constitution, skillList); break;
        case "Intelligence": var finalSkillList = getSkillListFromGeneral(scoreName, GeneralSkillList.intelligence, skillList); break;
        case "Wisdom": var finalSkillList = getSkillListFromGeneral(scoreName, GeneralSkillList.wisdom, skillList); break;
        case "Charisma": var finalSkillList = getSkillListFromGeneral(scoreName, GeneralSkillList.charisma, skillList); break;
    }


    function ProficiencyConvert(level) {
        switch (level) {
            case 0: return "None";
            case 1: return "Proficient";
            case 2: return "Expertise";
        }
    }

    return (<Row className="pb-2">
        <Col xs="2">
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
                            <th style={{ width: "15%" }}>{ProficiencyConvert(savingThrowDetails.proficiency)}</th>
                            <th style={{ width: "5%" }}>{savingThrowDetails.proficiency * profBonus + value}</th>
                            <th style={{ width: "60%" }}>{"Saving Throw"}</th>
                        </tr>
                        {_.map(finalSkillList, (skill, i) =>
                            <tr key={i}>
                                <td style={{ width: "15%" }}>{ProficiencyConvert(skill.proficiency)}</td>
                                <td style={{ width: "5%" }}>{skill.proficiency * profBonus + value}</td>
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