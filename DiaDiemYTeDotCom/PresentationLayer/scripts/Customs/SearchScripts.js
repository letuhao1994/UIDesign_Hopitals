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
        eventAction: 'click',
        eventLabel: 'Seach on Map'
    });

    ga('send', {
        hitType: 'event',
        eventCategory: 'Search Key',
        eventAction: 'fill',
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
        eventAction: 'click',
        eventLabel: 'Seach'
    });

    var searchTerm = "Type: " + searchTypeValue + "||Name:" + txtSearchValue;
    ga('send', {
        hitType: 'event',
        eventCategory: 'Search Key',
        eventAction: 'fill',
        eventLabel: searchTerm
    });
}