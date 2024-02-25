'use client'
import { useState } from "react"
export default () => {
    const [toogle, setToogle] = useState(false);
    return (
        <div className="w-full bg-[#f6f6f9] h-10 items-center flex flex-row">
            <ul className="flex flex-row topTabs justify-between w-full">
                <li onMouseEnter={()=>setToogle(true)} onMouseLeave={()=>setToogle(false)}>
                    <a id="new-object" href="#" 
                    > + </a>
                    {toogle && <ul className="absolute">
                        <li><a href="/">New issue</a></li>
                        <li><a href="/">New category</a></li>
                        <li><a href="/">New version</a></li>
                        <li><a href="/">Log time</a></li>
                        <li><a href="/">New document</a></li>
                        <li><a href="/">New wiki page</a></li>
                        <li><a href="/">New file</a></li>
                    </ul>}
                </li>
                <li>
                    <a href="/">Overview</a>
                </li>
                <li>
                    <a href="/">Activity</a>
                </li>
                <li>
                    <a href="/">Issues</a>
                </li>
                <li>
                    <a href="/">Spent time</a>
                </li>
                <li>
                    <a href="/">Gantt</a>
                </li>
                <li>
                    <a href="/">Agile</a>
                </li>
                <li>
                    <a href="/">Backlog</a>
                </li>
                <li>
                    <a href="/">Calendar</a>
                </li>
                <li>
                    <a href="/">Documents</a>
                </li>
                <li>
                    <a href="/">Wiki</a>
                </li>
                <li>
                    <a href="/">Files</a>
                </li>
                <li>
                    <a href="/">Repository</a>
                </li>
                <li>
                    <a href="/">Settings</a>
                </li>
                <li>
                    <a href="/">Issue templates</a>
                </li>
            </ul>
        </div>
    )
}