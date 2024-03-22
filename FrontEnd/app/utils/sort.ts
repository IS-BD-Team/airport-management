export default function Sort(data: [],
    columnIndex: string) {
    function sort(start: number, end: number):any[] {
        let mid = Math.floor((start + end)/ 2);
        if (start >= end) {
            return data.slice(start, start+1);
        }
        const left = sort(start, mid);
        const right = sort(mid+1 , end);
        return merge(left, right);
    }
    function merge(left: any[], right: any[]):[] {
        let temp:any[] = [];
        let i = 0;
        let j = 0;
        while (i < left.length && j < right.length) {
            if ((left[i][columnIndex] as string).toLowerCase() < (right[j][columnIndex] as string).toLowerCase()) {
                temp.push(left[i]);
                i++;
            } else {
                temp.push(right[j]);
                j++;
            }
        }
        while (i < left.length) {
            temp.push(left[i]);
            i++;
        }
        while (j < right.length) {
            temp.push(right[j]);
            j++;
        }
        return temp as [];
    }
    return sort(0, data.length - 1);
    
}