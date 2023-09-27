const API_URL = "/api/"
const token = localStorage.getItem("token");
async function request(method, url, body) {
    const jsonSent = {
        method: method,
        headers: {
            "Content-Type": "application/json",
            Accept: "application/json",
            Authorization: "Bearer " + localStorage.getItem("token")
        }
    };
    if (body) {
        jsonSent.body = JSON.stringify(body)
    }
    const res = await fetch(API_URL + url, jsonSent)
    if (res.ok) {
        return res.json();
    }
    else {
        console.log(res)
    }
}

export default {
    fetch: (url) => request("GET", url),
    post: (url, body) => request("POST", url, body)
}