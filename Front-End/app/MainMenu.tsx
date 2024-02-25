'use client'
import { useState } from "react"
export default () => {
    const [toogle, setToogle] = useState(false);
    return (
        <div className="w-full bg-[#f6f6f9] h-10 items-center lg:flex flex-row my-2 hidden">
            <ul className="flex flex-row topTabs justify-between w-full">
                <li onMouseEnter={()=>setToogle(true)} onMouseLeave={()=>setToogle(false)}>
                    <a id="new-object" href="#" 
                    > + </a>
                    {toogle && <ul className="absolute bg-[#f6f6f9] insideTab">
                        <li><a href="/">New issue</a></li>
                        <li><a href="/">New category</a></li>
                        <li><a href="/">New version</a></li>
                        <li><a href="/">Log time</a></li>
                        <li><a href="/">New document</a></li>
                        <li><a href="/">New wiki page</a></li>
                        <li><a href="/">New file</a></li>
                    </ul>}
                </li>
                <li className="hover:border-b-4 hover:border-b-[#614ba6]">
                    <a href="/">Overview</a>
                </li>
                <li className="hover:border-b-4 hover:border-b-[#614ba6]">
                    <a href="/">Activity</a>
                </li>
                <li className="hover:border-b-4 hover:border-b-[#614ba6]">
                    <a href="/">Issues</a>
                </li>
                <li className="hover:border-b-4 hover:border-b-[#614ba6]">
                    <a href="/">Spent time</a>
                </li>
                <li className="hover:border-b-4 hover:border-b-[#614ba6]">
                    <a href="/">Gantt</a>
                </li>
                <li className="hover:border-b-4 hover:border-b-[#614ba6]">
                    <a href="/">Agile</a>
                </li>
                <li className="hover:border-b-4 hover:border-b-[#614ba6]">
                    <a href="/">Backlog</a>
                </li>
                <li className="hover:border-b-4 hover:border-b-[#614ba6]">
                    <a href="/">Calendar</a>
                </li>
                <li className="hover:border-b-4 hover:border-b-[#614ba6]">
                    <a href="/">Documents</a>
                </li>
                <li className="hover:border-b-4 hover:border-b-[#614ba6]">
                    <a href="/">Wiki</a>
                </li>
                <li className="hover:border-b-4 hover:border-b-[#614ba6]">
                    <a href="/">Files</a>
                </li>
                <li className="hover:border-b-4 hover:border-b-[#614ba6]">
                    <a href="/">Repository</a>
                </li>
                <li className="hover:border-b-4 hover:border-b-[#614ba6]">
                    <a href="/">Settings</a>
                </li>
                <li className="hover:border-b-4 hover:border-b-[#614ba6]">
                    <a href="/">Issue templates</a>
                </li>
            </ul>
        </div>
    )
}