import React from "react";

export function getModifierFromScore(abilityScoreValue) {
    return Math.floor((abilityScoreValue - 10) / 2);
}