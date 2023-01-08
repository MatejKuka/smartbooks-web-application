import PersonalStatistics from "../types/PersonalStatistics";


function FilteredPSArrayBySearchedPhrase(personalStatisticsToFilter: PersonalStatistics[], searchedPhrase: string) {
    return personalStatisticsToFilter?.filter(
        ps => ps.lesson.title.toLowerCase().includes(searchedPhrase.toLowerCase())
    );
}


export default FilteredPSArrayBySearchedPhrase;