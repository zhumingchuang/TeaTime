using UnityEngine;


public class Examples : MonoBehaviour
{
    void Start()
    {
        // TeaTimer v0.4 Alpha

        // By Andrés Villalobos > andresalvivar@gmail.com > twitter.com/matnesis
        // In collaboration with Antonio Zamora > tzamora@gmail.com > twitter.com/tzamora
        // Created 2014/12/26 12:21 am

        // TeaTimer is a fast & simple queue for timed callbacks, designed as a
        // MonoBehaviour extension set, focused on solving common coroutines patterns.

        // Just put 'TeaTimer.cs' somewhere in your folders and call it inside any
        // MonoBehaviour using 'this.tt'.

        this.ttAppend("Queue name", 2, () =>
        {
            Debug.Log("2 second since start " + Time.time);
        })
        .ttAppendLoop(3, delegate(LoopHandler loop)
        {
            // An append loop will run frame by frame for all his duration.
            // loop.t holds the fraction of time by frame.
            Camera.main.backgroundColor = Color.Lerp(Color.black, Color.white, loop.t);
        })
        .ttAppend(2, () =>
        {
            Debug.Log("The append loop started 5 seconds ago  " + Time.time);
        })
        .ttInvoke(1, () =>
        {
            Debug.Log("ttInvoke is arbitrary and ignores the queue " + Time.time);
        })
        .ttLock(); // Locks the queue, ignoring new appends until all callbacks are done.

        // And that's it!

        // Some details
        // - Execution starts inmediatly
        // - Locking a queue ensures a safe run during continuous calls
        // - Naming a queue is recommended, but optional
        // - You can use a YieldInstruction instead of time in ttAppend (Dotween!)
        // - Queues are unique to his MonoBehaviour
    }
}