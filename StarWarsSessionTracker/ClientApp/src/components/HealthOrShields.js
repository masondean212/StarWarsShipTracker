import React from 'react';
import { Container } from 'reactstrap';
import { getModifierFromScore } from '../utils/functions';

function HealthOrShields({ partDetails, currentStats, abilityScore, type }) {

    return (<Container className="square border mb-2 rounded-1 text-center">
        <div className="mb-2 text-muted h6">
            {type} POINTS
        </div>
        <div>
            {currentStats.currentPoints} / {(currentStats.rolledPoints + getModifierFromScore(abilityScore) * 6) * partDetails.modifier}
        </div>
        <div className="square border-top mb-1 mb-2 text-muted h6">
            TEMPORARY {type} POINTS
        </div>
        <div>
            {currentStats.temporaryPoints}
        </div>
        <div className="square border-top mb-1 mb-2 text-muted h6">
            {type} TYPE
        </div>
        <div>
            {partDetails.name}
        </div>
    </Container>);
}

export default HealthOrShields;