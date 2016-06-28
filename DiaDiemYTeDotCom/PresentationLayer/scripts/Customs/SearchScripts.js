function GoTopHopistals() {
    window.location.replace("/Home/Home?tab=rating");

    ga('send', {
        hitType: 'event',
        eventCategory: 'Home',
        eventAction: 'tab selected',
        eventLabel: 'Top hopistals by rating'
    });
}

function GoTopHopistalsByArea1() {
    window.location.replace("/Home/Home?tab=area1");

    ga('send', {
        hitType: 'event',
        eventCategory: 'Home',
        eventAction: 'tab selected',
        eventLabel: 'Top hopistals by area1'
    });
}

function GoTopHopistalsByArea2() {
    window.location.replace("/Home/Home?tab=area2");

    ga('send', {
        hitType: 'event',
        eventCategory: 'Home',
        eventAction: 'tab selected',
        eventLabel: 'Top hopistals by area2'
    });
}

function GoTopHopistalsBySpecialist() {
    window.location.replace("/Home/Home?tab=specialist");

    ga('send', {
        hitType: 'event',
        eventCategory: 'Home',
        eventAction: 'tab selected',
        eventLabel: 'Top hopistals by specialists'
    });
}

function GoTopHopistalsByArea11() {
    window.location.replace("/Home/Home?tab=area1&tab2=Hà Nội");

    ga('send', {
        hitType: 'event',
        eventCategory: 'Home',
        eventAction: 'tab selected',
        eventLabel: 'Top hopistals by area1 - Ha Noi'
    });
}

function GoTopHopistalsByArea12() {
    window.location.replace("/Home/Home?tab=area1&tab2=Tp. Hồ Chí Minh");

    ga('send', {
        hitType: 'event',
        eventCategory: 'Home',
        eventAction: 'tab selected',
        eventLabel: 'Top hopistals by area1 - Tp. Ho Chi Minh'
    });
}

function GoTopHopistalsBySpecialist1() {
    window.location.replace("/Home/Home?tab=specialist&tab2=Chấn thương chỉnh hình");

    ga('send', {
        hitType: 'event',
        eventCategory: 'Home',
        eventAction: 'tab selected',
        eventLabel: 'Top hopistals by specialists - Chấn thương chỉnh hình'
    });
}

function GoTopHopistalsBySpecialist2() {
    window.location.replace("/Home/Home?tab=specialist&tab2=Da liễu");

    ga('send', {
        hitType: 'event',
        eventCategory: 'Home',
        eventAction: 'tab selected',
        eventLabel: 'Top hopistals by specialists - Da liễu'
    });
}

function GoTopHopistalsBySpecialist3() {
    window.location.replace("/Home/Home?tab=specialist&tab2=Đa khoa");

    ga('send', {
        hitType: 'event',
        eventCategory: 'Home',
        eventAction: 'tab selected',
        eventLabel: 'Top hopistals by specialists - Đa khoa'
    });
}

function GoTopHopistalsBySpecialist4() {
    window.location.replace("/Home/Home?tab=specialist&tab2=Khoa nhi");

    ga('send', {
        hitType: 'event',
        eventCategory: 'Home',
        eventAction: 'tab selected',
        eventLabel: 'Top hopistals by specialists - Khoa nhi'
    });
}

function GoTopHopistalsBySpecialist5() {
    window.location.replace("/Home/Home?tab=specialist&tab2=Mắt");

    ga('send', {
        hitType: 'event',
        eventCategory: 'Home',
        eventAction: 'tab selected',
        eventLabel: 'Top hopistals by specialists - Mắt'
    });
}

function GoTopHopistalsBySpecialist6() {
    window.location.replace("/Home/Home?tab=specialist&tab2=Nhiệt đới");

    ga('send', {
        hitType: 'event',
        eventCategory: 'Home',
        eventAction: 'tab selected',
        eventLabel: 'Top hopistals by specialists - Nhiệt đới'
    });
}

function GoTopHopistalsBySpecialist7() {
    window.location.replace("/Home/Home?tab=specialist&tab2=Phụ sản");

    ga('send', {
        hitType: 'event',
        eventCategory: 'Home',
        eventAction: 'tab selected',
        eventLabel: 'Top hopistals by specialists - Phụ sản'
    });
}

function GoTopHopistalsBySpecialist8() {
    window.location.replace("/Home/Home?tab=specialist&tab2=Răng hàm mặt");

    ga('send', {
        hitType: 'event',
        eventCategory: 'Home',
        eventAction: 'tab selected',
        eventLabel: 'Top hopistals by specialists - Răng hàm mặt'
    });
}

function GoTopHopistalsBySpecialist9() {
    window.location.replace("/Home/Home?tab=specialist&tab2=Tai mũi họng");

    ga('send', {
        hitType: 'event',
        eventCategory: 'Home',
        eventAction: 'tab selected',
        eventLabel: 'Top hopistals by specialists - Tai mũi họng'
    });
}

function GoTopHopistalsBySpecialist10() {
    window.location.replace("/Home/Home?tab=specialist&tab2=Tâm thần");

    ga('send', {
        hitType: 'event',
        eventCategory: 'Home',
        eventAction: 'tab selected',
        eventLabel: 'Top hopistals by specialists - Tâm thần'
    });
}

function GoTopHopistalsBySpecialist11() {
    window.location.replace("/Home/Home?tab=specialist&tab2=Tim mạch");

    ga('send', {
        hitType: 'event',
        eventCategory: 'Home',
        eventAction: 'tab selected',
        eventLabel: 'Top hopistals by specialists - Tim mạch'
    });
}

function GoTopHopistalsBySpecialist12() {
    window.location.replace("/Home/Home?tab=specialist&tab2=Ung bướu");

    ga('send', {
        hitType: 'event',
        eventCategory: 'Home',
        eventAction: 'tab selected',
        eventLabel: 'Top hopistals by specialists - Ung bướu'
    });
}

function GoTopHopistalsBySpecialist13() {
    window.location.replace("/Home/Home?tab=specialist&tab2=Y học cổ truyền");

    ga('send', {
        hitType: 'event',
        eventCategory: 'Home',
        eventAction: 'tab selected',
        eventLabel: 'Top hopistals by specialists - Y học cổ truyền'
    });
}

function SearchOnMaps() {
    var txtSearch = document.getElementById('txtSearchAutoComplete');
    var txtSearchValue = txtSearch.value;
    var path = "/Search/ViewOnMaps?txtSearch=" + txtSearchValue;

    var placeId = document.getElementById('txtSearchPlaceId');
    var placeIdStr = placeId.value;
    path += "&txtPlaceId=" + placeIdStr;

    window.location.replace(path);

    ga('send', {
        hitType: 'event',
        eventCategory: 'Search',
        eventAction: 'button clicked',
        eventLabel: 'Seach on Map'
    });

    ga('send', {
        hitType: 'event',
        eventCategory: 'Search Key',
        eventAction: 'textbox filled',
        eventLabel: txtSearchValue
    });
}

function Search() {
    var txtSearch = document.getElementById('txtSearchId');
    var txtSearchValue = txtSearch.value;
    var path = "/Search/Search?txtSearch=" + txtSearchValue;

    var searchType = document.getElementById('ddlSearchOptions');
    var searchTypeValue = searchType.value;
    path += "&ddlSearchOptions=" + searchTypeValue;

    window.location.replace(path);

    ga('send', {
        hitType: 'event',
        eventCategory: 'Search',
        eventAction: 'button clicked',
        eventLabel: 'Seach'
    });

    var searchTerm = "Type: " + searchTypeValue + "||Name:" + txtSearchValue;
    ga('send', {
        hitType: 'event',
        eventCategory: 'Search Key',
        eventAction: 'textbox filled',
        eventLabel: searchTerm
    });
}