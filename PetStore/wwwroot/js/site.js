/
function AdminLogin(rank) {
    const adminBar = document.getElementById('Admin');
    const loginBar = document.getElementById('Login');
    if (rank > 0) {
        loginBar.className = "nav - item hidden";
    }
    if (rank > 1) {
        adminBar.className = "nav - item";
    }
}