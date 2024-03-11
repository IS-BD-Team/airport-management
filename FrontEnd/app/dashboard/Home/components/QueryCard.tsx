type QueryCardProps = {
    text: string;
}

export default function QueryCard(props : QueryCardProps) {
    return (
        <div className="flex flex-col justify-between p-4 mx-auto space-y-4 bg-white shadow-md rounded-lg">
            {props.text}

            <button className="bg-sky-700 p-1 rounded-md">Consultar</button>
        </div>
    );
}
