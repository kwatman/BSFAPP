export const FormatDate = (date) => {
    const thisDate = new Date(date)
    const formattedDate = thisDate.getDate()+'/'+(thisDate.getMonth()+1)+'/'+thisDate.getFullYear()+' - '+thisDate.getHours()+':'+thisDate.getMinutes()
    return formattedDate
}