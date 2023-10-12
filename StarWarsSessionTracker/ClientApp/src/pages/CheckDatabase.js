import { useState } from 'react';
import { Button } from 'reactstrap';
import api from '../utils/api';
import ShipAmmunitionList from '../storage/ShipAmmunitionJSON';
import ShipWeaponList from '../storage/ShipWeaponsJSON';

function CheckDatabase() {

    const [modifications, completeModifications] = useState("primary");
    const [weapons, completeWeapons] = useState("primary");
    const [ammunition, completeAmmunition] = useState("primary");
    async function UpdateModifications() {
        ForwardApiResult(await (await fetch("https://sw5eapi.azurewebsites.net/api/starshipModification")).json());
    }
    async function ForwardApiResult(modifications) {
        await api.post('database/UpdateStarShipFeatures', modifications)
        .then(res => completeModifications(GetButtonColor(res)));
    }
    async function UpdateWeapons(){
        await api.post('database/UpdateStarShipWeapons',ShipWeaponList)
        .then(res => completeWeapons(GetButtonColor(res)));
    }
    async function UpdateAmmunition(){
        await api.post('database/UpdateStarShipAmmunition',ShipAmmunitionList)
        .then(res => completeAmmunition(GetButtonColor(res)));
    }
    function GetButtonColor(result) {
        if (result = "Ok") {
            return "success"
        }
        else {
            return "danger"
        }
    }
    return (<>
        <Button color={modifications} onClick={UpdateModifications}>Update Modifications</Button>
        <Button color={weapons} onClick={UpdateWeapons}>Update Weapons</Button>
        <Button color={ammunition} onClick={UpdateAmmunition}>Update Ammunition</Button>
    </>);
}
export default CheckDatabase;