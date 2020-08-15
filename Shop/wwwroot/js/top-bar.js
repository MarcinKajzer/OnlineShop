let accountIcon = document.querySelector(".account-icon");
let popupAccountOptions = document.querySelector(".account-options-popup")

if ("ontouchstart" in document.documentElement) {
    window.addEventListener("click", (event) => {
        if (event.target != accountIcon && event.target != popupAccountOptions) {
            popupAccountOptions.classList.remove("visible")
        }
    })

    accountIcon.addEventListener("click", () => {
        popupAccountOptions.classList.toggle("visible")
    })
}
else {
    accountIcon.addEventListener("mouseover", () => {
        popupAccountOptions.classList.add("visible")
    })
    accountIcon.addEventListener("mouseout", () => {
        popupAccountOptions.classList.remove("visible")
    })
}
