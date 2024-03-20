type AddFormInputProps = {
    data: { name: string; label: string; type: string };
    options?: {value: string; name: string}[];
};

export default function AddFormInput(props: AddFormInputProps) {
    switch (props.data.type) {
        case "text":
            return (
                <>
                    <label htmlFor={props.data.label}>
                        {props.data.name + ":"}
                    </label>
                    <input
                        className="border-[2px] border-solid rounded-lg border-[#e3e5ec] p-[2%]"
                        name={props.data.label}
                        type="text"
                    />
                </>
            );
        case "checkbox":
            return (
                <div className="flex mt-4">
                    <label htmlFor={props.data.label} className="mr-4">
                        {props.data.name + ":"}
                    </label>
                    <input
                        className="border-[2px] border-solid rounded-lg border-[#e3e5ec] p-[2%]"
                        name={props.data.label}
                        type="checkbox"
                    />
                </div>
            );
        case "select":
            return (
                <>
                    <label htmlFor={props.data.label}>
                        {props.data.name + ":"}
                    </label>
                    <select
                        className="border-[2px] border-solid rounded-lg border-[#e3e5ec] p-[2%]"
                        name={props.data.label}
                    >
                        {props.options?.map((value, index) => {return(<option key={index} value={value.value}>value.name</option>)})}
                    </select>
                </>
            );
            case "number":
                return (
                    <>
                        <label htmlFor={props.data.label}>
                            {props.data.name + ":"}
                        </label>
                        <input
                            className="border-[2px] border-solid rounded-lg border-[#e3e5ec] p-[2%]"
                            name={props.data.label}
                            type="number"
                        />
                    </>
                );
    }
}
