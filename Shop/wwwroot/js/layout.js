document.querySelector(".man-nav-button").addEventListener("click", () => {
    toggleNavigationVisibility(".man-navigation")
});

document.querySelector(".woman-nav-button").addEventListener("click", () => {
    toggleNavigationVisibility(".woman-navigation")
})

document.querySelector(".man-navigation .close-button").addEventListener("click", () => {
    toggleNavigationVisibility(".man-navigation");
})

document.querySelector(".woman-navigation .close-button").addEventListener("click", () => {
    toggleNavigationVisibility(".woman-navigation");
})

function toggleNavigationVisibility(navSelector) {
    document.querySelector(navSelector).classList.toggle("open-navigation");
    document.querySelector(navSelector + " .close-button").classList.toggle("animated-close-button");
}

window.addEventListener("scroll", function (e) {

    if (window.scrollY >= 50 && window.innerWidth > 800) {
        document.querySelector(".top-bar").classList.add("small-top-bar")
    }
    else {
        document.querySelector(".top-bar").classList.remove("small-top-bar")
    }
});


let accountIcon = document.querySelector(".account-icon");
let popupAccountOptions = document.querySelector(".options div")

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
