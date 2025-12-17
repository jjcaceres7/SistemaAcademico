function toggleDarkMode() {
    document.body.classList.toggle("dark");

    const isDark = document.body.classList.contains("dark");
    localStorage.setItem("darkMode", isDark ? "1" : "0");
}

document.addEventListener("DOMContentLoaded", () => {
    if (localStorage.getItem("darkMode") === "1") {
        document.body.classList.add("dark");
    }
});