function SearchOnMaps() {
    var txtSearch = document.getElementById('txtSearchAutoComplete');
    var txtSearchValue = txtSearch.value;
    window.location.replace("/Search/ViewOnMaps?txtSearch=" + txtSearchValue);

    ga('send', {
        hitType: 'event',
        eventCategory: 'Search',
        eventAction: 'click',
        eventLabel: 'Seach on Map'
    });
}