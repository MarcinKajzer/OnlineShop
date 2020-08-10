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


           
