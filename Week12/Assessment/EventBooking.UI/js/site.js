// global helper (optional)
function getToken(){
    if (eventId === 0) {
        alert("Invalid Event ID");
        window.location.href = "/";
    }
    return localStorage.getItem("token");
    
}