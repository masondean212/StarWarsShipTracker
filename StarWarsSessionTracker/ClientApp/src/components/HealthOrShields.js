import React from 'react';
import { CardTitle, Row, Card, CardSubtitle } from 'reactstrap';
import { getModifierFromScore } from '../utils/functions';

function HealthOrShields({ partDetails, currentStats, abilityScore, type }) {

    return (<>
        <Row>
            <Card>
                <CardSubtitle
                    className="mb-2 text-muted"
                    tag="h6"
                >
                    {type} POINTS
                </CardSubtitle>
                <CardTitle>
                    {currentStats.currentPoints} / {(currentStats.rolledPoints + getModifierFromScore(abilityScore) * 6) * partDetails.modifier}
                </CardTitle>
            </Card>
        </Row>
        <Row>
            <Card>
                <CardSubtitle
                    className="mb-2 text-muted"
                    tag="h6"
                >
                    TEMPORARY {type} POINTS
                </CardSubtitle>
                <CardTitle>
                    {currentStats.temporaryPoints}
                </CardTitle>
            </Card>
        </Row>
        <Row>
            <Card>
                <CardSubtitle
                    className="mb-2 text-muted"
                    tag="h6"
                >
                    {type} TYPE
                </CardSubtitle>
                <CardTitle>
                    {partDetails.name}
                </CardTitle>
            </Card>
        </Row>
    </>);
}

export default HealthOrShields;