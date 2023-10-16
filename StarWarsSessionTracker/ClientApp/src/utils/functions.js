import React from "react";

export function getModifierFromScore(abilityScoreValue) {
    return Math.floor((abilityScoreValue - 10) / 2);
}
export function valueAddPlusIfPositive(value) {
    if (value < 0) {
        return value;
    }
    else {
        return "+" + value;
    }
}