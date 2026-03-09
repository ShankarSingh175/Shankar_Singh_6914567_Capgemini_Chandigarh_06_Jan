// Email validation function
function isValidEmail(email) {
    const regex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return regex.test(email);
}

// Register Form
document.getElementById("registerForm").addEventListener("submit", function(e) {
    e.preventDefault();

    const username = document.getElementById("regUsername").value.trim();
    const email = document.getElementById("regEmail").value.trim();
    const password = document.getElementById("regPassword").value;
    const confirmPassword = document.getElementById("regConfirmPassword").value;

    if (!isValidEmail(email)) {
        alert("Invalid email format!");
        return;
    }

    if (password.length < 6) {
        alert("Password must be at least 6 characters long!");
        return;
    }

    if (password !== confirmPassword) {
        alert("Passwords do not match!");
        return;
    }

    // Store user in localStorage
    const user = { username, email, password };
    localStorage.setItem(email, JSON.stringify(user));

    alert("Registration Successful!");
    document.getElementById("registerForm").reset();
});

// Login Form
document.getElementById("loginForm").addEventListener("submit", function(e) {
    e.preventDefault();

    const email = document.getElementById("loginEmail").value.trim();
    const password = document.getElementById("loginPassword").value;

    const storedUser = localStorage.getItem(email);

    if (!storedUser) {
        alert("User not found!");
        return;
    }

    const user = JSON.parse(storedUser);

    if (user.password === password) {
        alert("Login Successful! Welcome " + user.username);
    } else {
        alert("Incorrect Password!");
    }

    document.getElementById("loginForm").reset();
});