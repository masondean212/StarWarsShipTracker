import React from 'react';
import { Button } from 'reactstrap';
import api from '../utils/api';
import ShipAmmunitionList from '../storage/ShipAmmunitionJSON';
import ShipWeaponList from '../storage/ShipWeaponsJSON';

function CheckDatabase() {

    async function UpdateModifications() {
        ForwardApiResult(await (await fetch("https://sw5eapi.azurewebsites.net/api/starshipModification")).json());
    }
    async function ForwardApiResult(modifications) {
        console.log(modifications);
        await api.post('database/UpdateStarShipFeatures', modifications);
    }
    async function UpdateWeapons(){
        await api.post('database/UpdateStarShipWeapons',ShipWeaponList);
    }
    async function UpdateAmmunition(){
        await api.post('database/UpdateStarShipAmmunition',ShipAmmunitionList);
    }
    return (<>
        <Button color="primary" onClick={UpdateModifications}>Update Modifications</Button>
        <Button color="primary" onClick={UpdateWeapons}>Update Weapons</Button>
        <Button color="primary" onClick={UpdateAmmunition}>Update Ammunition</Button>
    </>);
}
export default CheckDatabase;